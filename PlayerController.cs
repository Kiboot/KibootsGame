using Godot;
using System;

public class PlayerController : KinematicBody2D
{
    private int speed = 200;
    private int gravity = 5000;
    private float friction = .1f;
    private float acceleration = 0.5f;
    private int jumpHeight = 300;
    private int dashSpeed = 800;
    private bool isDashing = false;
    private Vector2 velocity = new Vector2();
    public override void _Ready()
    {
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
 public override void _Process(float delta)
 {
    if(!isDashing){
        int direction = 0;

        if(Input.IsActionPressed("ui_left")){
            direction -=1;
        }
        if(Input.IsActionPressed("ui_right")){
            direction +=1;
        }
        if(direction != 0 ){
            velocity.x = Mathf.Lerp(velocity.x, direction * speed, acceleration);
        }else{
            velocity.x = Mathf.Lerp(velocity.x, 0, friction);
        }
    }
    
    if (Input.IsActionJustPressed("jump")){
        if(IsOnFloor()){velocity.y -= 2000;}
    }

    if(Input.IsActionJustPressed("dash")){

        if(Input.IsActionPressed("ui_left")){
        velocity.x = -dashSpeed;
        isDashing = true;
        }
        if(Input.IsActionPressed("ui_right")){
            velocity.x = +dashSpeed;
            isDashing = true;
        }


    }




    

       velocity.y += gravity * delta;
       MoveAndSlide(velocity, Vector2.Up);     
 }
}
