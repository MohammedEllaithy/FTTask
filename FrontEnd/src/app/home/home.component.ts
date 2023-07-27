import { Component } from '@angular/core';
import { first } from 'rxjs/operators';

import { User } from '@app/_models';
import { UserService } from '@app/_services';
import { OrderPipe } from 'ngx-order-pipe';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent {
    loading = false;
    users?: User[];
  


    //constructor(private userService: UserService) { }
    constructor(private userService: UserService) {
       
      }

    ngOnInit() {
        this.loading = true;
        this.userService.getAll().pipe().subscribe(users => {
            this.loading = false;
            this.users = users;
        });
    }
}