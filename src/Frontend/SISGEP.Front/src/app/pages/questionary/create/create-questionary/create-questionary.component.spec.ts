import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateQuestionaryComponent } from './create-questionary.component';

describe('CreateQuestionaryComponent', () => {
  let component: CreateQuestionaryComponent;
  let fixture: ComponentFixture<CreateQuestionaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateQuestionaryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateQuestionaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
