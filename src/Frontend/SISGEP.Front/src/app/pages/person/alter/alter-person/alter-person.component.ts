import { Component, OnInit, Input  } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { PersonType } from 'src/app/interface/person-interface';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-alter-person',
  templateUrl: './alter-person.component.html',
  styleUrls: ['./alter-person.component.css']
})
export class AlterPersonComponent implements OnInit {

  @Input() personId!: string;

  personForm!: FormGroup;

  constructor(public activeModal: NgbActiveModal,
    private fb: FormBuilder,
    private http: HttpClient,
    private router: Router) { }

  ngOnInit(): void {
    this.personForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      isActive: [true],
      cpf: ['', Validators.required],
      personType: PersonType.Benefited,
      address: this.fb.group({
        postalCode: ['', Validators.required],
        thoroughfare: ['', Validators.required],
        number: [0, Validators.required],
        neighborhood: ['', Validators.required],
        complement: [''],
        city: ['', Validators.required],
        state: ['', Validators.required]
      })
    });

    this.loadPersonData(this.personId);
  }

  closeModal(sendData: any) {
    this.activeModal.close(sendData);
  }
  
  loadPersonData(personId: string) {
    const url = `/api/Person/${personId}`;
    this.http.get(url).subscribe((data: any) => {
      this.personForm.patchValue(data);
    }, error => {
      console.error('Error', error);
    });
  }

  updatePerson() {
    if (this.personForm.valid) {
      const formData = this.personForm.value;
      const url = `/api/Person/${this.personId}`;

      const headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'id': this.personId
      });

      this.http.put(url, formData, { headers })
        .subscribe({
          next: (response) => {
            alert('Dados atualizados com sucesso!');
            window.location.reload();
          },
          error: (error) => {
            console.error('Error:', error);
          }
        });
    } 
    else {
      console.log('Form is invalid');
    }
  }
}
