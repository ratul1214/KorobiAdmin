import {Component, OnInit} from '@angular/core';
import {UserService} from 'src/app/user.service';


@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  public username: string;

  constructor(public service: UserService) {
  }

  ngOnInit() {
  }

  onSubmit() {
    this.service.register().subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.service.formModel.reset();

        } else {
          res.errors.forEach(element => {
            switch (element.code) {
              case 'DuplicateUserName':

                break;

              default:

                break;
            }
          });
        }
      },
      err => {
        console.log(err);
      }
    );
  }

}
