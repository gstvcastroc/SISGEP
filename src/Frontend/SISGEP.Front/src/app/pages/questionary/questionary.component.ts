import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { AlterQuestionaryComponent } from './alter/alter-questionary/alter-questionary.component';
import { CreateQuestionaryComponent } from './create/create-questionary/create-questionary.component';
import { DeleteQuestionaryComponent } from './delete/delete-questionary/delete-questionary.component';

@Component({
  selector: 'app-questionary',
  templateUrl: './questionary.component.html',
  styleUrls: ['./questionary.component.css']
})
export class QuestionaryComponent implements OnInit {

  constructor(private _httpClient: HttpClient, private _modalService: NgbModal) { }

  ngOnInit(): void {
  }

  questionarios: any = [
    { id : 1, questionario: 'Cadastro de Alpha', projeto: 'Projeto Alpha', datainc : '2022-09-29 00:00:00' },
    { id : 2, questionario: 'Cadastro de Beta', projeto: 'Projeto Beta', datainc : '2022-09-29 00:00:00' },
    { id : 3, questionario: 'Cadastro de Gama', projeto: 'Projeto Alpha', datainc : '2022-09-29 00:00:00' },
    { id : 4, questionario: 'Cadastro de Andromeda', projeto: 'Projeto Beta', datainc : '2022-09-29 00:00:00' },
    { id : 5, questionario: 'Cadastro de Orion', projeto: 'Projeto Alpha', datainc : '2022-09-29 00:00:00' },
    { id : 6, questionario: 'Cadastro de Morpheus', projeto: 'Projeto Beta', datainc : '2022-09-29 00:00:00' }];

    newQuestionary() : void{
      this._modalService.open(CreateQuestionaryComponent,
        {
          size: 'lg',
          modalDialogClass: 'modal-dialog modal-dialog-centered'
        });
    }

    editQuestionary(id : string) : void{
      let _modalRef = this._modalService.open(AlterQuestionaryComponent,
        {
          size: 'lg',
          modalDialogClass: 'modal-dialog modal-dialog-centered'
        });

        //_modalRef.componentInstance.id = id;
    }

    deleteQuestionary(id : string) : void{
      let _modalRef = this._modalService.open(DeleteQuestionaryComponent,
        {
          size: 'lg',
          modalDialogClass: 'modal-dialog modal-dialog-centered'
        });

        //_modalRef.componentInstance.id = id;
    }
}
