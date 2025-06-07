import {
  ChangeDetectorRef,
  Component,
  effect,
  OnInit,
  signal,
  ViewChild,
} from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { PropertiesService } from '../../../services/properties/properties.service';
import { TableModule } from 'primeng/table';
import { Dialog } from 'primeng/dialog';
import { Ripple } from 'primeng/ripple';
import { ButtonModule } from 'primeng/button';
import { ToastModule } from 'primeng/toast';
import { ToolbarModule } from 'primeng/toolbar';
import { ConfirmDialog } from 'primeng/confirmdialog';
import { InputTextModule } from 'primeng/inputtext';
import { TextareaModule } from 'primeng/textarea';
import { CommonModule } from '@angular/common';
import { FileUpload } from 'primeng/fileupload';
import { SelectModule } from 'primeng/select';
import { Tag } from 'primeng/tag';
import { RadioButton } from 'primeng/radiobutton';
import { Rating } from 'primeng/rating';
import { FormsModule } from '@angular/forms';
import { InputNumber } from 'primeng/inputnumber';
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';
import { Table } from 'primeng/table';
import { DropdownModule } from 'primeng/dropdown';
import { IProperty } from '../../../types/properties';

interface Column {
  field: string;
  header: string;
  customExportHeader?: string;
}

interface ExportColumn {
  title: string;
  dataKey: string;
}

@Component({
  selector: 'app-properties',
  standalone: true,
  imports: [
    TableModule,
    Dialog,
    // Ripple,
    SelectModule,
    ToastModule,
    ToolbarModule,
    ConfirmDialog,
    InputTextModule,
    TextareaModule,
    CommonModule,
    FileUpload,
    DropdownModule,
    Tag,
    RadioButton,
    Rating,
    InputTextModule,
    FormsModule,
    InputNumber,
    IconFieldModule,
    InputIconModule,ButtonModule
  ],
  providers: [MessageService, ConfirmationService],
  
  templateUrl: './admin-properties-page.component.html',
  styleUrl: './admin-properties-page.component.scss',
  styles: [
    `
      :host ::ng-deep .p-dialog .property-image {
        width: 150px;
        margin: 0 auto 2rem auto;
        display: block;
      }
    `,
  ],
})
export class AdminPropertiesPageComponent {
  propertyDialog: boolean = false;

  properties = signal<IProperty[]>([]);

  property!: IProperty | undefined;

  selectedProperties!: IProperty[] | null;

  submitted: boolean = false;

  statuses!: any[];

  @ViewChild('dt') dt!: Table;

  cols!: Column[];

  exportColumns!: ExportColumn[];

  constructor(
    public propertiesService: PropertiesService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private cd: ChangeDetectorRef
  ) {
    this.loadDemoData()
    console.log("properties page on constructor ")
  }

  ngOnInit() {
    
  }

  exportCSV() {
    this.dt.exportCSV();
  }

  loadDemoData() {
    effect(() => {
      console.log(this.properties())
      this.properties.set(this.propertiesService.properties());
    });
    // this.propertyService.getProperties().then((data) => {
    //     this.properties = data;
    //     this.cd.markForCheck();
    // });

    this.statuses = [
      { label: 'INSTOCK', value: 'instock' },
      { label: 'LOWSTOCK', value: 'lowstock' },
      { label: 'OUTOFSTOCK', value: 'outofstock' },
    ];

    this.cols = [
      { field: 'code', header: 'Code', customExportHeader: 'IProperty Code' },
      { field: 'name', header: 'Name' },
      { field: 'image', header: 'Image' },
      { field: 'price', header: 'Price' },
      { field: 'category', header: 'Category' },
    ];

    this.exportColumns = this.cols.map((col) => ({
      title: col.header,
      dataKey: col.field,
    }));
  }

  openNew() {
    this.property = undefined;
    this.submitted = false;
    this.propertyDialog = true;
  }

  edit(property: IProperty) {
    this.property = { ...property };
    this.propertyDialog = true;
  }

  deleteSelectedProperties() {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected properties?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.propertiesService.filter(
          (val) => !this.selectedProperties?.includes(val)
        );
        this.selectedProperties = null;
        this.messageService.add({
          severity: 'success',
          summary: 'Successful',
          detail: 'Properties Deleted',
          life: 3000,
        });
      },
    });
  }

  hideDialog() {
    this.propertyDialog = false;
    this.submitted = false;
  }

  delete(property: IProperty) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + property.title + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.propertiesService.delete(property).subscribe({
            error: (error) => {
              this.property = undefined;
              this.messageService.add({
                severity: 'success',
                summary: 'Successful',
                detail: 'IProperty Deleted',
                life: 3000,
              });
            }
        });
        
      },
    });
  }

  findIndexById(id: number): number {
    let index = -1;
    for (let i = 0; i < this.properties.length; i++) {
      if (this.properties()[i].id === id) {
        index = i;
        break;
      }
    }

    return index;
  }

  createId(): number {
    let id = '';
    var chars =
      'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    for (var i = 0; i < 5; i++) {
      id += chars.charAt(Math.floor(Math.random() * chars.length));
    }
    return Date.now();
  }

  getSeverity(status: string) {
    switch (status) {
      case 'INSTOCK':
        return 'success';
      case 'LOWSTOCK':
        return 'warn';
      case 'OUTOFSTOCK':
        return 'danger';
      default:
        return "info";
    }
  }

  saveProperty() {
    this.submitted = true;

    if (this.property?.title?.trim()) {
      if (this.property.id) {
        this.propertiesService.properties()[this.findIndexById(this.property.id)] = this.property;
        this.messageService.add({
          severity: 'success',
          summary: 'Successful',
          detail: 'IProperty Updated',
          life: 3000,
        });
      } else {
        this.property.id = this.createId();
        this.property.thumbnail = 'property-placeholder.svg';
        this.propertiesService.add(this.property);
        this.messageService.add({
          severity: 'success',
          summary: 'Successful',
          detail: 'IProperty Created',
          life: 3000,
        });
      }

      // this.properties = [...this.properties];
      this.propertyDialog = false;
      this.property = undefined;
    }
  }
}
