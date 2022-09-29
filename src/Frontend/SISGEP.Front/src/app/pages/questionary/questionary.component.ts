import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-questionary',
  templateUrl: './questionary.component.html',
  styleUrls: ['./questionary.component.css']
})
export class QuestionaryComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  questionarios: any = [
    { id : 1, questionario: 'Cadastro de Alpha', projeto: 'Projeto Alpha', datainc : '2022-09-29 00:00:00' },
    { id : 2, questionario: 'Cadastro de Beta', projeto: 'Projeto Beta', datainc : '2022-09-29 00:00:00' },
    { id : 3, questionario: 'Cadastro de Gama', projeto: 'Projeto Alpha', datainc : '2022-09-29 00:00:00' },
    { id : 4, questionario: 'Cadastro de Andromeda', projeto: 'Projeto Beta', datainc : '2022-09-29 00:00:00' },
    { id : 5, questionario: 'Cadastro de Orion', projeto: 'Projeto Alpha', datainc : '2022-09-29 00:00:00' },
    { id : 6, questionario: 'Cadastro de Morpheus', projeto: 'Projeto Beta', datainc : '2022-09-29 00:00:00' }];
}
