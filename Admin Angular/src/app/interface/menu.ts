export interface Imenu{
  menuItemId?:number;
  menuItemName: string;
  menuItemDescription: string;
  price: number;
  vegOrNonVeg: string;
  menuItemCategory: string;
  calories: number;
  isAvailable:string;
  preparationTime:number;
}
export interface IUser{
  userID?:number
  name:string;
  email:string;
  password:string;
  roleType:number
}
export interface Iorder{
orderid :number;
orderdate:string;
orderstatus:string;
ordertotal:number;
paymenttype:string;
orderitem:IorderItem[]
}
export interface IorderItem{
  name:string;
  quantity:number;
}