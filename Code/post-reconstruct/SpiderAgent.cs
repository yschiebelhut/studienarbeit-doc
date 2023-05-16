using System.IO;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class SpiderAgent : Agent {
    public SpiderController spiderController;

    public override void OnEpisodeBegin() {
        spiderController.moveToStart();
    }

    public override void CollectObservations(VectorSensor sensor) {
        for (int i = 0; i < 12; i++) {
            sensor.AddObservation(normalize(spiderController.allServos[i].currentAngle));
        }
    }

    public override void OnActionReceived(ActionBuffers actionBuffers) {
        var continuousActionsOut = actionBuffers.ContinuousActions;
        
        for (int i = 0; i < continuousActionsOut.Length - 1; i++) {
            if (continuousActionsOut[i] < 1 && continuousActionsOut[i] > -1) {
                continuousActionsOut[i] = denormalize(continuousActionsOut[i]);
            }
        }

        for (int i = 0; i < 12; i++) {
            spiderController.allServos[i].targetAngle = continuousActionsOut[i];
        }
        SetReward(spiderController.getReward());
        
        //reset if invalid
        if (spiderController.isTurned()) {
            print("spider turned!");
            EndEpisode();
        }
    }
    
    //convert angles from degrees to normalized value in range [-1, 1]
    private float denormalize(float val) {
        return val * 360f;
    }

    private float normalize(float val) {
        return val / 360f;
    }
}