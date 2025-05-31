export interface IProperty {
  id: number;
  title: string;
  price: number;
  description: string;
  addressDescription: string;
  previewImageLink: string;
  status: string;
  listingType: string;
  category: string;
  album: string[];
  thumbnail: string;
  location: {
    countryName: string;
    countryId: number;
    regionName: string;
    regionId: number;
    cityName: string;
    cityId: number;
  };
}
export interface IPropertyCDTO {
  title: string;
  price: number;
  description: string;
  listingType: string;
  addressDescription: string;
  latitude: number;
  longitude: number;
  thumbnail: File;
  Images: File[];
  organizationId: number;
  categoryId: string;
  countryId: number;
  regionId: number;
  cityId: number;
}
