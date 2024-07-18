import { Component, OnInit } from '@angular/core';
import { ProjectDataService } from './project.data.service';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { PaginationDTO } from '../../DTO/PaginationDTO';
import { Project } from '../../DTO/Project';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrl: './project.component.css',
  providers: [ProjectDataService]
})
export class ProjectComponent implements OnInit {

  page!: PaginationDTO<Project>;
  searchString: string = '';
  buttonText: string = '';

  constructor(private projectdataservice: ProjectDataService, private router: Router, public authService: AuthService) { }

  ngOnInit() {
    this.loadProjects('', '', '', 1);
    this.setButtonText();
  }

  loadProjects(sortBy: string, sortType: string, searchString: string, pageNumber: number) {
    if (sortBy == null) sortBy = '';
    if (sortType == null) sortType = '';
    if (searchString == null) searchString = '';
    if (pageNumber == null) pageNumber = 1;
    let id: number | null = null;
    if (!this.isNotEmployee()) {
      id = this.authService.getUserId();
    }
    this.projectdataservice.getProjects(sortBy, sortType, searchString, pageNumber, id)
      .subscribe((data: PaginationDTO<Project>) => this.page = data);
  }

  isNotEmployee(): boolean {
    return this.authService.getPosition() !== 'Employee';
  }

  changeStatus(id: number): void {
    this.projectdataservice.changeStatus(id).subscribe(() => {
      this.loadProjects(this.page.sortBy!, this.page.sortType!, this.page.searchString!, this.page?.pageIndex ?? 1);
    });
  }

  addProject(): void {
    this.router.navigate(['/projects/add']);
  }

  editProject(id: number): void {
    this.router.navigate(['/projects/edit', id]);
  }

  setButtonText(): void {
    const role = this.authService.getPosition();
    this.buttonText = this.isNotEmployee() ? 'Edit' : 'Details';
  }
}
