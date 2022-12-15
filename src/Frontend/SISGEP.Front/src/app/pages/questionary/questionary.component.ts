import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlterQuestionaryComponent } from './alter/alter-questionary/alter-questionary.component';
import { CreateQuestionaryComponent } from './create/create-questionary/create-questionary.component';
import { DeleteQuestionaryComponent } from './delete/delete-questionary/delete-questionary.component';
import { Survey } from 'src/app/interface/questionary-interface';
import { map, Observable } from 'rxjs';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-questionary',
  templateUrl: './questionary.component.html',
  styleUrls: ['./questionary.component.css']
})
export class QuestionaryComponent implements OnInit {

  constructor(private _httpClient: HttpClient, private _modalService: NgbModal) { }

  surveyList : Survey[] = [];

  ngOnInit(): void {

    this.surveyList = this.loadQuestionary();
  }

  _httpRequestUrl = 'https://localhost:5001/api/';

    loadQuestionary() : Survey[] {
      let survey : Survey[] = [];

      this._httpClient.get<Survey[]>(`${this._httpRequestUrl}Survey`).pipe(map(response => <Survey[]>response)).subscribe((data : Survey[]) => { survey.push(...data) });

      return survey;
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

      this._httpClient.get<any>(`${this._httpRequestUrl}Survey/` + id).subscribe(data => {
        _modalRef.componentInstance.name = data.name;
        _modalRef.componentInstance.date = data.date;
      })
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
