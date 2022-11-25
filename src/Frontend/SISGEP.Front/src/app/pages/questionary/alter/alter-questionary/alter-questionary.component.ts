import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-alter-questionary',
  templateUrl: './alter-questionary.component.html',
  styleUrls: ['./alter-questionary.component.css']
})
export class AlterQuestionaryComponent implements OnInit {

  constructor(public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
  }

  closeModal(sendData: any) {
    this.activeModal.close(sendData);
  }
}
