import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-delete-questionary',
  templateUrl: './delete-questionary.component.html',
  styleUrls: ['./delete-questionary.component.css'],
})
export class DeleteQuestionaryComponent implements OnInit {
  constructor(public activeModal: NgbActiveModal) {}

  ngOnInit(): void {}

  closeModal(sendData: any) {
    this.activeModal.close(sendData);
  }
}
