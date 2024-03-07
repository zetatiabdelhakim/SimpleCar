using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class Car : MonoBehaviour
{
    private float speed = 0.05f;
    private bool turbo = false;
    public GameObject cameraObject;
    public GameObject road;
    private int newRoad = 70;
    private float score;
    private float angle;
    public Text scoreText;
    public Text speedText;
    public Text turboText;
    // Start is called before the first
    private float turboTime_ = 0.0f;
    void Start(){
        InvokeRepeating("scorePlus", 0f, 1f);
        InvokeRepeating("speedPlus", 0f, 15f);
        InvokeRepeating("turboTime", 0f, 1f);
    }
    void Update()
    {
        // Move the car forward
        transform.Translate(Vector3.forward * speed);

        if (angle < 70 && Input.GetAxis("Horizontal") > 0)
        {
            transform.Rotate(Vector3.up, 0.5f);
            angle += 0.5f;

        }
        if (angle > -70 && Input.GetAxis("Horizontal") < 0)
        {
            transform.Rotate(Vector3.up, -0.5f);
            angle -= 0.5f;
        }
        if (Input.GetAxis("Vertical") > 0 && turbo)
        {
            turbo = false;
            doTurbo();
        }
        if (Input.GetAxis("Vertical") < 0 && speed > 0.2f)
        {
           speed -= 0.005f;
        }
    }

    private void LateUpdate()
    {
        cameraObject.transform.position = transform.position - transform.forward * 5f + Vector3.up * 3f;
        cameraObject.transform.LookAt(transform);
        if(transform.position.y <= -20){
            Invoke("ReloadGame", 2f);
        }
        UpdateScoreText();
        UpdateSpeedText();
        UpdateTurboText();
    }

    void OnCollisionEnter(Collision other) {
        GameObject gameObject = other.gameObject;
        if(gameObject.tag == "Cube"){
            if(speed > 0.06f){
                speed -= 0.05f;
                turbo = false;
                turboTime_ = 0;
            }
            return;
        }
        if(gameObject.tag == "Box"){
            if(speed > 0.6f){
                speed = 0.1f;
                turboTime_ = 0;
                score = 0;
                turbo = false;
                return;
            }
            if(speed > 0.11f){
                speed -= 0.05f;
                turboTime_ = 0;
            }
            Destroy(gameObject, 1f);
            return;
        }
        if(gameObject.tag == "Coin"){
            score += 100;
            Destroy(gameObject);
            return;
        }
        if(gameObject.tag == "Car"){
            speed = 0;
            return;
        }
    }
    private void OnCollisionExit(Collision other) {
        GameObject gameObject = other.gameObject;
        if(gameObject.tag == "Road"){
            Destroy(gameObject.transform.parent.gameObject, 1f);
            GameObject o = Instantiate(road, road.transform.position, road.transform.rotation);
            o.transform.Translate(new Vector3(0, 0, newRoad));
            newRoad += 10;
        }
    }
    void scorePlus(){ score += speed * 10; }
    void speedPlus(){ if(speed < 1){speed += 0.05f; }}
    void doTurbo(){
        float x = speed;
        speed = 1f;}
    void ReloadGame()
    { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
    void UpdateScoreText()
    { scoreText.text = "Score: " + score.ToString(); }
    void UpdateSpeedText()
    { 
        int speedInt = (int) (speed * 120);
        speedText.text = "Speed: " + speedInt.ToString() + " Km/h";
        }
    void UpdateTurboText(){
        if(turbo){
            turboText.text = "Turbo";
        }
        else{
            turboText.text = "";
        }
    }
    void turboTime(){
        turboTime_ ++;
        if(turboTime_ >= 30){
            turbo = true;
            turboTime_ = 0;
        }
    }
    public float getSpeed(){
        return speed;
    }
}
