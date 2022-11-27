import { Component, OnInit, Input  } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-alter-person',
  templateUrl: './alter-person.component.html',
  styleUrls: ['./alter-person.component.css']
})
export class AlterPersonComponent implements OnInit {

  @Input() personId!: string;

  constructor(public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
  }

  closeModal(sendData: any) {
    this.activeModal.close(sendData);
  }
}
