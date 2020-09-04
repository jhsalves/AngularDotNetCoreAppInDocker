import { Component, OnInit } from '@angular/core';
import { ClientService } from '../../../services/client.service';
import { Client } from '../../../../model/client';
import { ClientAddress } from 'src/model/clientAddress';

@Component({
  selector: 'app-add-client',
  templateUrl: './add-client.component.html',
  styleUrls: ['./add-client.component.css']
})
export class AddClientComponent implements OnInit {

  constructor(private clientService: ClientService) { }

  client: Client = {
    id: 0,
    name: '',
    birthDate: new Date(),
    clientAddresses: [] as ClientAddress[]
  };

  submitted = false;

  ngOnInit(): void {
  }


  saveClient(): void {

    this.clientService.create(this.client)
      .subscribe(
        response => {
          console.log(response);
          this.submitted = true;
        },
        error => {
          console.log(error);
        });
  }

  public onDate(event): void {
    console.log(this.client);
    this.client.birthDate = event;
  }


  reset(): void {
    this.submitted = false;
    this.client = {
      birthDate: new Date(),
      id: 0,
      name: ''
    };
  }
}
