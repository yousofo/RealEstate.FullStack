export interface IProperty {
  id: number;
  title: string;
  price: number;
  description: string;
  thumbnail: string;
  addressDescription: string;
  status: string;
  listingType: string;
  category: string;
  album: string[];
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

export interface ICategory {
  id: number
  title: string
 image: string
}
export interface IListingType {
  id: number
  title: string
 image: string
}
