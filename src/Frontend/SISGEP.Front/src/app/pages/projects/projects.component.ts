import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css']
})
export class ProjectsComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  projects: any = [
    { source: '../assets/images/thumbnail.jpg', title: 'Projeto Alpha', description: 'Mussum Ipsum, cacilds vidis litro abertis. Interagi no mé, cursus quis, vehicula ac nisi.Praesent vel viverra nisi. Mauris aliquet nunc non turpis scelerisque, eget.Aenean aliquam molestie leo, vitae iaculis nisl.Quem num gosta di mé, boa gentis num é.' },
    { source: '../assets/images/thumbnail.jpg', title: 'Projeto Beta', description: 'Mussum Ipsum, cacilds vidis litro abertis. Interagi no mé, cursus quis, vehicula ac nisi.Praesent vel viverra nisi. Mauris aliquet nunc non turpis scelerisque, eget.Aenean aliquam molestie leo, vitae iaculis nisl.Quem num gosta di mé, boa gentis num é.' },
    { source: '../assets/images/thumbnail.jpg', title: 'Projeto Gama', description: 'Mussum Ipsum, cacilds vidis litro abertis. Interagi no mé, cursus quis, vehicula ac nisi.Praesent vel viverra nisi. Mauris aliquet nunc non turpis scelerisque, eget.Aenean aliquam molestie leo, vitae iaculis nisl.Quem num gosta di mé, boa gentis num é.' },
    { source: '../assets/images/thumbnail.jpg', title: 'Projeto Genesis', description: 'Mussum Ipsum, cacilds vidis litro abertis. Interagi no mé, cursus quis, vehicula ac nisi.Praesent vel viverra nisi. Mauris aliquet nunc non turpis scelerisque, eget.Aenean aliquam molestie leo, vitae iaculis nisl.Quem num gosta di mé, boa gentis num é.'},
    { source: '../assets/images/thumbnail.jpg', title: 'Projeto Morpheus', description: 'Mussum Ipsum, cacilds vidis litro abertis. Interagi no mé, cursus quis, vehicula ac nisi.Praesent vel viverra nisi. Mauris aliquet nunc non turpis scelerisque, eget.Aenean aliquam molestie leo, vitae iaculis nisl.Quem num gosta di mé, boa gentis num é.'},
    { source: '../assets/images/thumbnail.jpg', title: 'Projeto Andromeda', description: 'Mussum Ipsum, cacilds vidis litro abertis. Interagi no mé, cursus quis, vehicula ac nisi.Praesent vel viverra nisi. Mauris aliquet nunc non turpis scelerisque, eget.Aenean aliquam molestie leo, vitae iaculis nisl.Quem num gosta di mé, boa gentis num é.' },
    { source: '../assets/images/thumbnail.jpg', title: 'Projeto Orion', description: 'Mussum Ipsum, cacilds vidis litro abertis. Interagi no mé, cursus quis, vehicula ac nisi.Praesent vel viverra nisi. Mauris aliquet nunc non turpis scelerisque, eget.Aenean aliquam molestie leo, vitae iaculis nisl.Quem num gosta di mé, boa gentis num é.' },
    { source: '../assets/images/thumbnail.jpg', title: 'Projeto Archiles', description: 'Mussum Ipsum, cacilds vidis litro abertis. Interagi no mé, cursus quis, vehicula ac nisi.Praesent vel viverra nisi. Mauris aliquet nunc non turpis scelerisque, eget.Aenean aliquam molestie leo, vitae iaculis nisl.Quem num gosta di mé, boa gentis num é.'}];
}
