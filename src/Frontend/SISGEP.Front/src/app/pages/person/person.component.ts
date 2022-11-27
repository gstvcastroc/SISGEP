import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { Person } from 'src/app/interface/person-interface';
import { CreatePersonComponent } from './create/create-person/create-person.component';
import { AlterPersonComponent } from './alter/alter-person/alter-person.component';
import { DeletePersonComponent } from './delete/delete-person/delete-person.component';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

  constructor(private _httpClient: HttpClient, private _modalService: NgbModal) { }

  ngOnInit(): void {
  }

  loadPerson() : Person[] {

    /*this._httpClient.get<Person[]>('https://localhost:5001/api/Project').subscribe(result => { projectsList = result }); Chamada HTTP para preencher a entidade*/

    let personList: Person[] = [
      { id: 1, name: 'Renato Mateus da Mota', docIdentify: '962.107.576-93' },
      { id: 2, name: 'Aparecida Bruna Maria Nascimento', docIdentify: '781.210.576-80' },
      { id: 3, name: 'Helena Elaine Castro', docIdentify: '398.649.646-74' },
      { id: 4, name: 'Jorge Marcos Carlos Souza', docIdentify: '204.206.126-37' },
      { id: 5, name: 'Eloá Benedita Melo', docIdentify: '802.743.926-40' },
      { id: 6, name: 'Marcelo Thales Lucca de Paula', docIdentify: '494.035.466-03' },
      { id: 7, name: 'Marcelo Thiago Paulo Galvão', docIdentify: '183.547.516-78' }
    ];

    return personList;
  }

  newPerson() : void{
    this._modalService.open(CreatePersonComponent,
      {
        size: 'lg',
        modalDialogClass: 'modal-dialog modal-dialog-centered'
      });
  }

  editPerson(id : number) : void{
    let _modalRef = this._modalService.open(AlterPersonComponent,
      {
        size: 'lg',
        modalDialogClass: 'modal-dialog modal-dialog-centered'
      });

      //_modalRef.componentInstance.id = id;
  }

  deletePerson(id : number) : void{
    let _modalRef = this._modalService.open(DeletePersonComponent,
      {
        size: 'lg',
        modalDialogClass: 'modal-dialog modal-dialog-centered'
      });

      //_modalRef.componentInstance.id = id;
  }
}
