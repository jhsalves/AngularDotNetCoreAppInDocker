import { Component, OnInit, Input } from '@angular/core';
import { ClientAddress } from 'src/model/clientAddress';

@Component({
  selector: 'client-addresses',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.css']
})
export class AddressComponent implements OnInit {

  newAddress: string;
  @Input() adresses: ClientAddress[];
  @Input() update = true;
  constructor() { }

  ngOnInit(): void {
  }
  removerEndereco(endereco) {
    this.adresses = this.adresses.filter(obj => obj.id !== endereco.id);
  }

  addEndereco() {
    if(!this.adresses){
      this.adresses = [];
    }
    this.adresses.push({
      id: 0,
      adressName: this.newAddress
    } as ClientAddress);
    this.newAddress = '';
  }
}
