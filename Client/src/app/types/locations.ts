export interface ILocation {
  place_id: string
  osm_id: string
  osm_type: string
  licence: string
  lat: string
  lon: string
  boundingbox: string[]
  class: string
  type: string
  display_name: string
  display_place: string
  display_address: string
  address: IAddress
}

export interface IAddress {
  [key: string]: string
  name: string
  county: string
  state: string
  postcode: string
  country: string
  country_code: string
}


export interface ILocationRDTO{
  cityId: number;
  cityName: string;
  regionId: number;
  regionName: string;
  countryId: number;
  countryName: string;
}



export interface ILocationDTO {
  cityName: string;
  regionName: string;
  countryName: string;
}