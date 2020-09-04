import { ClientAddress } from "./clientAddress";

export interface Client{
    id: number;
    name: string;
    birthDate: Date;
    clientAddresses?: ClientAddress[] | null | undefined;
}
