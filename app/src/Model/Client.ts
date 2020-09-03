import { ClientAddress } from "./ClientAddress";

export interface Client{
    id: number;
    name: string;
    birthDate: Date;
    clientAdress?: ClientAddress | null | undefined;
}
