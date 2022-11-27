import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { AlterQuestionaryComponent } from './alter/alter-questionary/alter-questionary.component';
import { CreateQuestionaryComponent } from './create/create-questionary/create-questionary.component';
import { DeleteQuestionaryComponent } from './delete/delete-questionary/delete-questionary.component';
import { Survey } from 'src/app/interface/questionary-interface';
import { Observable } from 'rxjs';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-questionary',
  templateUrl: './questionary.component.html',
  styleUrls: ['./questionary.component.css']
})
export class QuestionaryComponent implements OnInit {

  constructor(private _httpClient: HttpClient, private _modalService: NgbModal) { }

  ngOnInit(): void {
  }

  _httpRequestUrl = 'https://localhost:5001/api/';

    loadQuestionary() : Observable<Survey[]> {

    /*questionarios: any = [
    { id : 1, questionario: 'Cadastro de Alpha', projeto: 'Projeto Alpha', datainc : '2022-09-29 00:00:00' },
    { id : 2, questionario: 'Cadastro de Beta', projeto: 'Projeto Beta', datainc : '2022-09-29 00:00:00' },
    { id : 3, questionario: 'Cadastro de Gama', projeto: 'Projeto Alpha', datainc : '2022-09-29 00:00:00' },
    { id : 4, questionario: 'Cadastro de Andromeda', projeto: 'Projeto Beta', datainc : '2022-09-29 00:00:00' },
    { id : 5, questionario: 'Cadastro de Orion', projeto: 'Projeto Alpha', datainc : '2022-09-29 00:00:00' },
    { id : 6, questionario: 'Cadastro de Morpheus', projeto: 'Projeto Beta', datainc : '2022-09-29 00:00:00' }];*/

      return this._httpClient.get<Survey[]>(this._httpRequestUrl + 'Survey');
    }

    newQuestionary() : void{
      this._modalService.open(CreateQuestionaryComponent,
        {
          size: 'lg',
          modalDialogClass: 'modal-dialog modal-dialog-centered'
        });
    }

    editQuestionary(id : Guid) : void{
      let _modalRef = this._modalService.open(AlterQuestionaryComponent,
        {
          size: 'lg',
          modalDialogClass: 'modal-dialog modal-dialog-centered'
        });

        //_modalRef.componentInstance.id = id;
    }

    deleteQuestionary(id : Guid) : void{
      let _modalRef = this._modalService.open(DeleteQuestionaryComponent,
        {
          size: 'lg',
          modalDialogClass: 'modal-dialog modal-dialog-centered'
        });

        //_modalRef.componentInstance.id = id;
    }
}
