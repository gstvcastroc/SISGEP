import { Component, OnInit, Input  } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Person } from 'src/app/interface/person-interface';

@Component({
  selector: 'app-alter-person',
  templateUrl: './alter-person.component.html',
  styleUrls: ['./alter-person.component.css']
})
export class AlterPersonComponent implements OnInit {

  @Input() name!: string;
  @Input() email!: string;
  @Input() password!: string;
  @Input() active!: boolean;
  @Input() cpf!: string;
  @Input() personType!: number;

  constructor(public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
  }

  closeModal(sendData: any) {
    this.activeModal.close(sendData);
  }
}
