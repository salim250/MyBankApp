import {Client} from "./client";

export class Extrait {
  date!: Date;
  operation!:string;
  montantRetire!: number
  montantVerse!: number
  client!:Client
}
