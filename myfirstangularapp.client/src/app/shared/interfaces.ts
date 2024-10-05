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
  customUserId: number;
  userName: string;
  password: string;
  email: string;
  phoneNumber?: string;
}

export interface Subscription {
  subscriptionID: number;
  subServiceID: number;
  customUserId: number;
  customUser?: User;
  plan: string;
  startDate: string;
  endDate: string;
  subService?: SubService;
}

export interface CreateSubscription {
  plan: Plan;
  subServiceID: number;
  customUserId: number;
}
export type Plan = 'Monthly' | 'Annual' | 'Weekly';
