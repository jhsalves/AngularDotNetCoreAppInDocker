import { Client } from "./client";

export interface ClientAddress{
    id: number;
    adressName: string;
    clientId: number;
    client: Client | null;
}
