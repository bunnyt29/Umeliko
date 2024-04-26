import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EditorComponent } from 'src/app/pages/materials/elements/components/editor/editor.component';
import { CourseService } from '../../services/course.service';
import { ToastrService } from 'ngx-toastr';
import { SectionsService } from '../../sections/services/sections.service';

@Component({
  selector: 'create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit{
  @ViewChild(EditorComponent) child: any;
  courseForm!: FormGroup; 
  materialId!: string;
  courseId!: string;
  sections: any[] = [];
  lessonsCount = 1;
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private courseService: CourseService,
    private toastr: ToastrService,
    private sectionsService: SectionsService
  ){}

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.materialId = params['materialId'];
    })

    this.courseForm = this.fb.group({
      'content': ['', Validators.required],
      'materialId': this.materialId
    });

    this.addSection();
  }

  routeToLesson() {
    this.router.navigate(["lesson"]);
  }

  createLesson(id: any):void {
    this.sections[id].push(this.sections.length);
  }

  addSection(): void {
    const newSection = {
      titleControl: new FormControl(''), // Use a FormControl for each title
      title: '',
      courseId: this.courseId
    };
    this.sections.push(newSection);
  }

  updateTitle(index: number, event: Event): void {
    const inputElement = event.target as HTMLInputElement;
    this.sections[index].title = inputElement.value;
  }

  create(): void {
    this.courseForm.patchValue({
      content: this.child.htmlContent
    });


    this.courseService.create(this.courseForm.value).subscribe(res => {
      this.courseId = res.courseId;
      
      this.sections.forEach(section => {
        section.courseId = this.courseId;
        section.title = section.titleControl.value; // Ensure title is updated
        this.sectionsService.create(section).subscribe(() => {
          console.log("Section created!");
        });
      });

      this.toastr.success("Курсът е успешно създадена!");

      this.router.navigate(["/profile/dashboard"]);
    })
  }
}
