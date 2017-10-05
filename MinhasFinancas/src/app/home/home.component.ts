import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    moduleId: module.id,
    styleUrls: ['../css/matrix-style.css', '../css/matrix-media.css'],
    templateUrl: 'home.component.html',
    encapsulation: ViewEncapsulation.None
})

export class HomeComponent implements OnInit {

    constructor(private router: Router) {

    }

    ngOnInit() {

        

    }

}