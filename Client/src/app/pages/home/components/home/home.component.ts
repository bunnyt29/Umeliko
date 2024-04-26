import { Component, OnInit } from '@angular/core';

import { AuthService } from 'src/app/pages/auth/services/auth.service';

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit{

  constructor(
    private authService: AuthService
  ) {}
  ngOnInit(): void {
    this.authService.isAuthenticated();
  }

}
