import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteQuestionaryComponent } from './delete-questionary.component';

describe('DeleteQuestionaryComponent', () => {
  let component: DeleteQuestionaryComponent;
  let fixture: ComponentFixture<DeleteQuestionaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteQuestionaryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteQuestionaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
