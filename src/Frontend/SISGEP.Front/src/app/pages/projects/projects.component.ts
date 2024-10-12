import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from '../modal/modal.component';
import { CreateProjectComponent } from './create/create-project/create-project.component';
import { Project } from 'src/app/interface/project-interface';
import { AlterProjectComponent } from './alter/alter-project/alter-project.component';
import { DeleteProjectComponent } from './delete/delete-project/delete-project.component';
import { Guid } from 'guid-typescript';
import { map } from 'rxjs';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css'],
})
export class ProjectsComponent implements OnInit {
  constructor(
    private _httpClient: HttpClient,
    private _modalService: NgbModal
  ) {}

  projectList: Project[] = [];

  ngOnInit(): void {
    this.projectList = this.loadProjects();
  }

  loadProjects(): Project[] {
    let project: Project[] = [];

    this._httpClient
      .get<Project[]>('/api/Project')
      .pipe(map((response) => <Project[]>response))
      .subscribe((data: Project[]) => {
        project.push(...data);
      });

    return project;
  }

  newProject(): void {
    this._modalService.open(CreateProjectComponent, {
      size: 'lg',
      modalDialogClass: 'modal-dialog modal-dialog-centered',
    });
  }

  editProject(ProjectId: Guid): void {
    let _modalRef = this._modalService.open(AlterProjectComponent, {
      size: 'lg',
      modalDialogClass: 'modal-dialog modal-dialog-centered',
    });

    this._httpClient
      .get<any>(`/api/Project/` + ProjectId)
      .subscribe((data) => {
        _modalRef.componentInstance.name = data.name;
        _modalRef.componentInstance.description = data.description;
        _modalRef.componentInstance.active = data.isActive;
        _modalRef.componentInstance.startDate = data.startDate;
        _modalRef.componentInstance.endDate = data.endDate;
      });
  }

  deleteProject(ProjectId: Guid): void {
    let _modalRef = this._modalService.open(DeleteProjectComponent, {
      size: 'lg',
      modalDialogClass: 'modal-dialog modal-dialog-centered',
    });
  }
}
