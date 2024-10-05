import { User } from "../shared/interfaces";

export interface SubService {
  subServiceID: number;
  subServiceName: string;
  subServiceDescription: string;
  subServiceImage: string;
  serviceID: number;
}

export interface Service {
  serviceID: number;
  serviceName: string;
  serviceDescription: string;
  serviceImage: string;
  subServices: SubService[];
}


