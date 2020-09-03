import { Component, OnInit } from '@angular/core';
import { ClientService } from '../../../services/client.service';
import { Client } from '../../../../Model/Client';

@Component({
  selector: 'app-list-client',
  templateUrl: './list-client.component.html',
  styleUrls: ['./list-client.component.css']
})
export class ListClientComponent implements OnInit {

  clients: Client[];
  currentClient: Client;
  currentIndex = -1;
  title = '';
  constructor(private clientService: ClientService) { }

  ngOnInit(): void {
    this.retrieveClients();
  }

  retrieveClients(): void {
    this.clientService.list()
      .subscribe(
        data => {
          this.clients = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  refreshList(): void {
    this.retrieveClients();
    this.currentClient = null;
    this.currentIndex = -1;
  }

  setActiveClient(tutorial, index): void {
    this.currentClient = tutorial;
    this.currentIndex = index;
  }

  removeAllClients(): void {
    this.clientService.delete(this.currentClient.id)
      .subscribe(
        response => {
          console.log(response);
          this.retrieveClients();
        },
        error => {
          console.log(error);
        });
  }
}
