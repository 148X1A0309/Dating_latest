
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserAcess } from '../../interfaces/user-access';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [FormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  userPassword!: string;
  userAcess: UserAcess = {
    userName: '',
    userPassword: '',
  };

  constructor(private router:Router){

  }

  login(userData: UserAcess) {
    console.log(userData.userName);
    this.router.navigate(['/login']);
  }

  register(){

  }

  cancel(){
    
  }
}
