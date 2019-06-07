import {LogManager, autoinject, View} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IdentityService} from "../services/identity-service";
import {AppConfig} from "../app-config";

export var log = LogManager.getLogger("app.Login.Index");

@autoinject
export class Login {

  private email: string;
  private password: string;
  //private email: string = "a@a.ee";
  //private password: string = "Password";

  constructor(
    private identityService: IdentityService,
    private appConfig: AppConfig,
    private router: Router
  ){
    log.debug('constructor running');
  }

  created(owningView: View, myView: View){
    log.debug('created');
  }

  bind(bindingContext: Object, overrideContext: Object){
    log.debug('bind');
  }

  attached(){
    log.debug('attached');
  }

  detached(){
    log.debug('detached');
  }

  unbind(){
    log.debug('unbind');
  }

  // ============= Router Events =============
  canActivate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('canActivate');
  }

  activate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('activate');
  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
  
  //============= View Method =======================
  submit():void{
    log.debug("submit", this.email, this.password);
    this.identityService.login(this.email, this.password)
      .then(jwtDTO => {
        if (jwtDTO.token !== undefined){
          log.debug("submit token", jwtDTO.token);
          this.appConfig.jwt = jwtDTO.token;
          this.router.navigateToRoute('home');
        }
      });
  }
}
