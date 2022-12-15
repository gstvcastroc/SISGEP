import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-alter-project',
  templateUrl: './alter-project.component.html',
  styleUrls: ['./alter-project.component.css']
})
export class AlterProjectComponent implements OnInit {

  @Input() name!: string;
  @Input() description!: string;
  @Input() active!: boolean;
  @Input() startDate!: Date;
  @Input() endDate!: Date;

  constructor(public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
  }

  closeModal(sendData: any) {
    this.activeModal.close(sendData);
  }
}
