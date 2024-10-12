import { Component, OnInit} from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { PersonType } from 'src/app/interface/person-interface';

@Component({
  selector: 'app-create-person',
  templateUrl: './create-person.component.html',
  styleUrls: ['./create-person.component.css']
})

export class CreatePersonComponent implements OnInit {  
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
      isActive: [false],
      cpf: ['', Validators.required],
      personType: [PersonType.Benefited], //Padrão Beneficiário
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
  }

  closeModal(sendData: any) {
    this.activeModal.close(sendData);
  }

  onSubmit() {
    debugger;
    if (this.personForm.valid) {
      const formData = this.personForm.value;
      //console.log('Form Data: ', formData);

      this.closeModal('dismiss');

      this.http.post(`api/Person`, formData)
      .subscribe({
        next: (response) => {
          console.log('Success!', response);
          this.router.navigate(['/person']);
          alert("Dados salvos com sucesso!")
        },
        error: (error) => {
          console.error('Error!', error);
        }
      });
    }
    else {
      console.log('Form is invalid');
    }
  }
}
