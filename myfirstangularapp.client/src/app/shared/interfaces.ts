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

export interface User {
  customUserId: number,
  userName: string,
  password: string,
  email: string,
  phoneNumber?: string
}
