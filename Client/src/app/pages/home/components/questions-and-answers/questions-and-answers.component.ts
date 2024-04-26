import { Component, OnInit } from '@angular/core';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'questions-and-answers',
  templateUrl: './questions-and-answers.component.html',
  styleUrls: ['./questions-and-answers.component.scss']
})

export class QuestionsAndAnswersComponent implements OnInit {
  panelStates: {[key: string]: boolean} = {};
  constructor(private cd: ChangeDetectorRef) { }
  ngOnInit(): void {
    this.panelStates['panel1'] = false;
    this.panelStates['panel2'] = false;
    this.panelStates['panel3'] = false;
    this.panelStates['panel4'] = false;
    this.panelStates['panel5'] = false;
  }

  expand(panelId: string, event: any): void {
    this.panelStates[panelId] = !this.panelStates[panelId];
    this.cd.detectChanges();

    if (event.style.display === "block") {
      event.style.display = "none";
    }
    else {
      event.style.display = "block";
    }
  }
}
