import { Client } from "./Client";

export interface ClientAddress{
    id: number;
    adressName: string;
    clientId: number;
    client: Client | null;
}
