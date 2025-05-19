export interface IProperty {
  id: number;
  title: string;
  description: string;
  addressDescription: string;
  price: number;
  previewImageLink: string;
  status: string;
  category: string;
  thumbnail: string;
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
