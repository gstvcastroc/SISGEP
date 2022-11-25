import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlterQuestionaryComponent } from './alter-questionary.component';

describe('AlterQuestionaryComponent', () => {
  let component: AlterQuestionaryComponent;
  let fixture: ComponentFixture<AlterQuestionaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AlterQuestionaryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AlterQuestionaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
