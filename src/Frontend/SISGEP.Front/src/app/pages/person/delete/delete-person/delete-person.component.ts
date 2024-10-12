import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-delete-person',
  templateUrl: './delete-person.component.html',
  styleUrls: ['./delete-person.component.css']
})
export class DeletePersonComponent implements OnInit {

  @Input() personId!: string;

  constructor(public activeModal: NgbActiveModal,
    private http: HttpClient,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  closeModal(sendData: any) {
    this.activeModal.close(sendData);
  }

  deletePerson() {
    const url = `api/Person/${this.personId}`;
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'id': this.personId
    });

    this.closeModal('dismiss');

    this.http.delete(url, { headers })
      .subscribe({
        next: (response) => {
          //console.log('Delete successful!', response);
          this.router.navigate(['/person']);
          alert("Dado excluído com sucesso!")
        },
        error: (error) => {
          console.error('Error:', error);
        }
      });
  }
}
