import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'phone'
})
export class PhonePipe implements PipeTransform {

  transform(value: string, ...args: unknown[]): unknown {
    //recive text and return like XXX XXX XXXX with spaces

    var noSpaces = value.replace(/\s/g, '');

    if(noSpaces.length<3){
      return noSpaces
    }
    
    if(noSpaces.length>7){
      return noSpaces.slice(0,3) + " " + noSpaces.slice(3,6) + " " + noSpaces.slice(6)
    }

    if(noSpaces.length>3){
      return noSpaces.slice(0,3) + " " + noSpaces.slice(3)
    }

    return noSpaces
  }

}
