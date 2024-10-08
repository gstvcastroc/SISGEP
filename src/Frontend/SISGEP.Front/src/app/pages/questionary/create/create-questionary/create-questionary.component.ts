import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-create-questionary',
  templateUrl: './create-questionary.component.html',
  styleUrls: ['./create-questionary.component.css']
})
export class CreateQuestionaryComponent implements OnInit {

  constructor(public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
  }

  closeModal(sendData: any) {
    this.activeModal.close(sendData);
  }
}
