import { Component, OnInit, ViewEncapsulation, Output, EventEmitter } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { User } from '../_models/index';
import { UserService } from '../_services/index';

@Component({

    moduleId: module.id,
    styleUrls: ['../css/matrix-style.css', '../css/matrix-media.css'],
    templateUrl: 'home.component.html',
    encapsulation: ViewEncapsulation.None
})

export class HomeComponent implements OnInit{
    currentUser: User;
    users: User[] = [];

    constructor(private userService: UserService) {
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    }

    ngOnInit() {
        this.loadAllUsers();
    }

    deleteUser(_id: string) {
        this.userService.delete(_id).subscribe(() => { this.loadAllUsers() });
    }

    private loadAllUsers() {
        this.userService.getAll().subscribe(users => { this.users = users; });
    }


}
