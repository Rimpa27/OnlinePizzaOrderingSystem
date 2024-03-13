export interface Imenu{
  name: string;
  description: string;
  price: number;
  foodtype: string;
  category: string;
  calories: number;
  preparationTime: number;
  photo: string;
}
export interface IUser{
  username:string;
  email:string;
  password:string;
  phone:number;
  line1:string;
  line2:string;
  city:string;
  pincode:number;
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