import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { map } from 'rxjs/operators';

import { Person } from 'src/app/interface/person-interface';
import { CreatePersonComponent } from './create/create-person/create-person.component';
import { AlterPersonComponent } from './alter/alter-person/alter-person.component';
import { DeletePersonComponent } from './delete/delete-person/delete-person.component';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

  constructor(private _httpClient: HttpClient, private _modalService: NgbModal) { }

  personList : Person[] = [];

  ngOnInit(): void {

    this.personList = this.loadPerson();
  }

  _httpRequestUrl = 'https://localhost:5001/api/';

  loadPerson() : Person[] {

    let person : Person[] = [];

    this._httpClient.get<Person[]>(`${this._httpRequestUrl}Person`).pipe(map(response => <Person[]>response)).subscribe((data : Person[]) => { person.push(...data) });

    person.splice(25, person.length);

    console.log(person)

    return person;
  }

  newPerson() : void{
    this._modalService.open(CreatePersonComponent,
      {
        size: 'lg',
        modalDialogClass: 'modal-dialog modal-dialog-centered'
      });
  }

  editPerson(PersonId : Guid) : void{
    let _modalRef = this._modalService.open(AlterPersonComponent,
      {
        size: 'lg',
        modalDialogClass: 'modal-dialog modal-dialog-centered'
      });

      _modalRef.componentInstance.PersonId = PersonId;
  }

  deletePerson(PersonId : Guid) : void{
    let _modalRef = this._modalService.open(DeletePersonComponent,
      {
        size: 'lg',
        modalDialogClass: 'modal-dialog modal-dialog-centered'
      });

      _modalRef.componentInstance.PersonId = PersonId;
  }
}
