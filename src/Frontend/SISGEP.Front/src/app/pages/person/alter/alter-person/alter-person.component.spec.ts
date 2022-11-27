import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlterPersonComponent } from './alter-person.component';

describe('AlterPersonComponent', () => {
  let component: AlterPersonComponent;
  let fixture: ComponentFixture<AlterPersonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AlterPersonComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AlterPersonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
