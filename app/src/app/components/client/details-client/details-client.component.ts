import { Component, OnInit } from '@angular/core';
import { Client } from '../../../../Model/Client';
import { ClientService } from '../../../services/client.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-details-client',
  templateUrl: './details-client.component.html',
  styleUrls: ['./details-client.component.css']
})
export class DetailsClientComponent implements OnInit {
  currentClient: Client = null;
  message = '';
  constructor(
    private clientService: ClientService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.message = '';
    this.getClient(this.route.snapshot.paramMap.get('id'));
  }

  getClient(id): void {
    this.clientService.get(id)
      .subscribe(
        data => {
          this.currentClient = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  updatePublished(status): void {

    this.clientService.update(this.currentClient.id, this.currentClient)
      .subscribe(
        response => {
          console.log(response);
        },
        error => {
          console.log(error);
        });
  }

  updateClient(): void {
    this.clientService.update(this.currentClient.id, this.currentClient)
      .subscribe(
        response => {
          console.log(response);
          this.message = 'The tutorial was updated successfully!';
        },
        error => {
          console.log(error);
        });
  }

  deleteClient(): void {
    this.clientService.delete(this.currentClient.id)
      .subscribe(
        response => {
          console.log(response);
          this.router.navigate(['/clients']);
        },
        error => {
          console.log(error);
        });
  }

}
