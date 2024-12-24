import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { EdashboardComponent } from './edashboard/edashboard.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';
import { authGuard } from './auth.guard';
import { CourselistComponent } from './courselist/courselist.component';

const routes: Routes = [
  {path:"",redirectTo:"home",pathMatch:'full'},
  {path:"home",component:HomeComponent},
  {path:"Login",component:LoginComponent},
  {path:"register",component:RegisterComponent,canDeactivate:[]},
  {path:"edashboard",component:EdashboardComponent,canActivate:[authGuard]},
  {path:"courselist", component:CourselistComponent},
  {path:"**",component:PagenotfoundComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
