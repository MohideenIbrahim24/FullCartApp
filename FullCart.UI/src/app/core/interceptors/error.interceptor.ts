import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { Observable, catchError, throwError } from "rxjs";

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private router: Router,private toastr: ToastrService ){

    }
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(
            catchError(error => {
                if(error){
                    if(error.status === 400){
                        this.toastr.error(error.error.message,error.error.statusCode);
                    }
                    if(error.status === 401){
                        this.toastr.error(error.error.message,error.error.statusCode);
                    }
                    if(error.status === 404){
                        this.toastr.error(error.message,error.status);
                        this.router.navigateByUrl('/');
                    }

                    if(error.status === 500){
                        this.router.navigateByUrl('/');
                    }
                }
                return throwError(error);
            })
        );
    }

}