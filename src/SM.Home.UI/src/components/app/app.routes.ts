import { Routes } from "@angular/router";
import { LoginComponent } from "../login/login.component";
import { HomeComponent } from "../home/home.component";
import { AuthGuard } from "../../services/guards/auth.guard";
import { ChannelComponent } from "../channel/channel.component";
import { SignupComponent } from "../signup/signup.component";

export const routes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'channel', component: ChannelComponent, canActivate: [AuthGuard]},
    { path: 'login', component: LoginComponent },
    { path: 'signup', component: SignupComponent },
    { path: '**', component: HomeComponent}
];