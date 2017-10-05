import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    moduleId: module.id,
    styleUrls: ['../css/matrix-login.css'],
    templateUrl: 'login.component.html',
    encapsulation: ViewEncapsulation.None
})

export class LoginComponent implements OnInit {
    fileName: string;
    constructor(private router: Router) {
         
    }

    ngOnInit() {
        this.fileName = "teste";
    }
     
}